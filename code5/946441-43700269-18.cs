    /// <summary>
    /// Class to automate the unpacking (and packing/writing) of RGB(A) colours in colour formats with packed bits.
    /// Inspired by https://github.com/scummvm/scummvm/blob/master/graphics/pixelformat.h
    /// This class works slightly differently than the ScummVM version, using 4-entry arrays for all data, with each entry
    /// representing one of the colour components, so the code can easily loop over them and perform the same action on each one.
    /// </summary>
    public class PixelFormatter
    {
        /// <summary>Standard PixelFormatter for .Net's RGBA format.</summary>
        public static PixelFormatter Format32BitArgb = new PixelFormatter(4, 8, 16, 8, 8, 8, 0, 8, 24, true);
        /// <summary>Number of bytes to read per pixel.</summary>
        private Byte bytesPerPixel;
        /// <summary>Amount of bits for each component (R,G,B,A)</summary>
        private Byte[] bitsAmounts = new Byte[4];
        /// <summary>Amount of bits to shift for each component (R,G,B,A)</summary>
        private Byte[] shiftAmounts = new Byte[4];
        /// <summary>Masks to limit the amount of bits for each component, derived from the bitsAmounts.</summary>
        private UInt32[] limitMasks = new UInt32[4];
        /// <summary>Multiplier for each component (R,G,B,A). If not explicitly given this can be derived from the number of bits.</summary>
        private Double[] multipliers = new Double[4];
        /// <summary>Defaults for for each component (R,G,B,A)</summary>
        private Byte[] defaults = new Byte[] { 0, 0, 0, 255 };
        /// <summary>True to read the input bytes as little-endian.</summary>
        private Boolean littleEndian;
        /// <summary>The colour components. Though most stuff will just loop an int from 0 to 4, this shows the order.</summary>
        private enum ColorComponent
        {
            Red = 0,
            Green = 1,
            Blue = 2,
            Alpha = 3
        }
        /// <summary>
        /// Creats a new PixelFormatter, with automatic calculation of colour multipliers using the CalculateMultiplier function.
        /// </summary>
        /// <param name="bytesPerPixel">Amount of bytes to read per pixel</param>
        /// <param name="redBits">Amount of bits to read for the red colour component</param>
        /// <param name="redShift">Amount of bits to shift the data to get to the red colour component</param>
        /// <param name="greenBits">Amount of bits to read for the green colour component</param>
        /// <param name="greenShift">Amount of bits to shift the data to get to the green colour component</param>
        /// <param name="blueBits">Amount of bits to read for the blue colour component</param>
        /// <param name="blueShift">Amount of bits to shift the data to get to the blue colour component</param>
        /// <param name="alphaBits">Amount of bits to read for the alpha colour component</param>
        /// <param name="alphaShift">Amount of bits to shift the data to get to the alpha colour component</param>
        /// <param name="littleEndian">True if the read bytes are interpreted as little-endian.</param>
        public PixelFormatter(Byte bytesPerPixel, Byte redBits, Byte redShift, Byte greenBits, Byte greenShift,
            Byte blueBits, Byte blueShift, Byte alphaBits, Byte alphaShift, Boolean littleEndian)
            : this(bytesPerPixel,
                redBits, redShift, CalculateMultiplier(redBits),
                greenBits, greenShift, CalculateMultiplier(greenBits),
                blueBits, blueShift, CalculateMultiplier(blueBits),
                alphaBits, alphaShift, CalculateMultiplier(alphaBits), littleEndian)
        { }
        /// <summary>
        /// Creates a new PixelFormatter.
        /// </summary>
        /// <param name="bytesPerPixel">Amount of bytes to read per pixel</param>
        /// <param name="redBits">Amount of bits to read for the red colour component</param>
        /// <param name="redShift">Amount of bits to shift the data to get to the red colour component</param>
        /// <param name="redMultiplier">Multiplier for the red component's value to adjust it to the normal 0-255 range.</param>
        /// <param name="greenBits">Amount of bits to read for the green colour component</param>
        /// <param name="greenShift">Amount of bits to shift the data to get to the green colour component</param>
        /// <param name="greenMultiplier">Multiplier for the green component's value to adjust it to the normal 0-255 range.</param>
        /// <param name="blueBits">Amount of bits to read for the blue colour component</param>
        /// <param name="blueShift">Amount of bits to shift the data to get to the blue colour component</param>
        /// <param name="blueMultiplier">Multiplier for the blue component's value to adjust it to the normal 0-255 range.</param>
        /// <param name="alphaBits">Amount of bits to read for the alpha colour component</param>
        /// <param name="alphaShift">Amount of bits to shift the data to get to the alpha colour component</param>
        /// <param name="alphaMultiplier">Multiplier for the alpha component's value to adjust it to the normal 0-255 range.</param>
        /// <param name="littleEndian">True if the read bytes are interpreted as little-endian.</param>
        public PixelFormatter(Byte bytesPerPixel, Byte redBits, Byte redShift, Double redMultiplier,
            Byte greenBits, Byte greenShift, Double greenMultiplier,
            Byte blueBits, Byte blueShift, Double blueMultiplier,
            Byte alphaBits, Byte alphaShift, Double alphaMultiplier, Boolean littleEndian)
        {
            this.bytesPerPixel = bytesPerPixel;
            this.littleEndian = littleEndian;
            this.bitsAmounts [(Int32)ColorComponent.Red] = redBits;
            this.shiftAmounts[(Int32)ColorComponent.Red] = redShift;
            this.multipliers [(Int32)ColorComponent.Red] = redMultiplier;
            this.limitMasks[(Int32)ColorComponent.Red] = GetLimitMask(redBits, redShift);
            this.bitsAmounts [(Int32)ColorComponent.Green] = greenBits;
            this.shiftAmounts[(Int32)ColorComponent.Green] = greenShift;
            this.multipliers [(Int32)ColorComponent.Green] = greenMultiplier;
            this.limitMasks[(Int32)ColorComponent.Green] = GetLimitMask(greenBits, greenShift);
            
            this.bitsAmounts [(Int32)ColorComponent.Blue] = blueBits;
            this.shiftAmounts[(Int32)ColorComponent.Blue] = blueShift;
            this.multipliers [(Int32)ColorComponent.Blue] = blueMultiplier;
            this.limitMasks[(Int32)ColorComponent.Blue] = GetLimitMask(blueBits, blueShift);
            
            this.bitsAmounts [(Int32)ColorComponent.Alpha] = alphaBits;
            this.shiftAmounts[(Int32)ColorComponent.Alpha] = alphaShift;
            this.multipliers [(Int32)ColorComponent.Alpha] = alphaMultiplier;
            this.limitMasks[(Int32)ColorComponent.Alpha] = GetLimitMask(alphaBits, alphaShift);
        }
        private static UInt32 GetLimitMask(Byte bpp, Byte shift)
        {
            return (UInt32)(((1 << bpp) - 1) << shift);
        }
        /// <summary>
        /// Using this multiplier instead of a basic int ensures a true uniform distribution of values of this bits length over the 0-255 range.
        /// </summary>
        /// <param name="colorComponentBitLength">Bits length of the color component</param>
        /// <returns>The most correct multiplier to convert colour components of the given bits length to a 0-255 range.</returns>
        public static Double CalculateMultiplier(Byte colorComponentBitLength)
        {
            return 255.0 / ((1 << colorComponentBitLength) - 1);
        }
        public Color GetColor(Byte[] data, Int32 offset)
        {
            UInt32 value = ArrayUtils.ReadIntFromByteArray(data, offset, this.bytesPerPixel, this.littleEndian);
            return GetColorFromValue(value);
        }
        public void WriteColor(Byte[] data, Int32 offset, Color color)
        {
            UInt32 value = GetValueFromColor(color);
            ArrayUtils.WriteIntToByteArray(data, offset, this.bytesPerPixel, this.littleEndian, value);
        }
        public Color GetColorFromValue(UInt32 readValue)
        {
            Byte[] components = new Byte[4];
            for (Int32 i = 0; i < 4; i++)
            {
                if (bitsAmounts[i] == 0)
                    components[i] = defaults[i];
                else
                    components[i] = GetChannelFromValue(readValue, (ColorComponent)i);
            }
            return Color.FromArgb(components[(Int32)ColorComponent.Alpha],
                                  components[(Int32)ColorComponent.Red],
                                  components[(Int32)ColorComponent.Green],
                                  components[(Int32)ColorComponent.Blue]);
        }
        private Byte GetChannelFromValue(UInt32 readValue, ColorComponent type)
        {
            UInt32 val = (UInt32)(readValue & limitMasks[(Int32)type]);
            val = (UInt32)(val >> this.shiftAmounts[(Int32)type]);
            Double valD = (Double)(val * multipliers[(Int32)type]);
            return (Byte)Math.Min(255, Math.Round(valD, MidpointRounding.AwayFromZero));
        }
        public UInt32 GetValueFromColor(Color color)
        {
            Byte[] components = new Byte[] { color.R, color.G, color.B, color.A};
            UInt32 val = 0;
            for (Int32 i = 0; i < 4; i++)
            {
                UInt32 mask = (UInt32)((1 << bitsAmounts[i]) - 1);
                Double tempValD = (Double)components[i] / this.multipliers[i];
                UInt32 tempVal = (Byte)Math.Min(mask, Math.Round(tempValD, MidpointRounding.AwayFromZero));
                tempVal = (UInt32)(tempVal << this.shiftAmounts[i]);
                val |= tempVal;
            }
            return val;
        }
    }
