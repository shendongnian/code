    /// <summary>
    /// Processes the given kernel to produce an array of pixels representing a 
    /// bitmap.
    /// </summary>
    /// <param name="pixels">The raw pixels of the image to blur</param>
    /// <param name="kernel">
    /// The Gaussian kernel to use when performing the method</param>
    /// <returns>An array of pixels representing the bitmap.</returns>
    public Pixel[,] ProcessKernel(Pixel[,] pixels, double[,] kernel)
    {
        int width = pixels.GetLength(0);
        int height = pixels.GetLength(1);
        int kernelLength = kernel.GetLength(0);
        int radius = kernelLength >> 1;
        int kernelSize = kernelLength * kernelLength;
        Pixel[,] result = new Pixel[width, height];
        // For each line
        for (int y = 0; y < height; y++)
        {
            // For each pixel
            for (int x = 0; x < width; x++)
            {
                // The number of kernel elements taken into account
                int processedKernelSize;
                // Colour sums
                double blue;
                double alpha;
                double divider;
                double green;
                double red = green = blue = alpha = divider = 
                             processedKernelSize = 0;
                // For each kernel row
                for (int i = 0; i < kernelLength; i++)
                {
                    int ir = i - radius;
                    int iposition = y + ir;
                    // Skip the current row
                    if (iposition < 0)
                    {
                        continue;
                    }
                    // Outwith the current bounds so break.
                    if (iposition >= height)
                    {
                        break;
                    }
                    // For each kernel column
                    for (int j = 0; j < kernelLength; j++)
                    {
                        int jr = j - radius;
                        int jposition = x + jr;
                        // Skip the column
                        if (jposition < 0)
                        {
                            continue;
                        }
                        if (jposition < width)
                        {
                            double k = kernel[i, j];
                            Pixel pixel = pixels[jposition, iposition];
                            divider += k;
                            red += k * pixel.R;
                            green += k * pixel.G;
                            blue += k * pixel.B;
                            alpha += k * pixel.A;
                            processedKernelSize++;
                        }
                    }
                }
                // Check to see if all kernel elements were processed
                if (processedKernelSize == kernelSize)
                {
                    // All kernel elements are processed; we are not on the edge.
                    divider = this.Divider;
                }
                else
                {
                    // We are on an edge; do we need to use dynamic divider or not?
                    if (!this.UseDynamicDividerForEdges)
                    {
                        // Apply the set divider.
                        divider = this.Divider;
                    }
                }
                // Check and apply the divider
                if ((long)divider != 0)
                {
                    red /= divider;
                    green /= divider;
                    blue /= divider;
                    alpha /= divider;
                }
                // Add any applicable threshold.
                red += this.Threshold;
                green += this.Threshold;
                blue += this.Threshold;
                alpha += this.Threshold;
                result[x, y].R = (byte)((red > 255) 
                               ? 255 : ((red < 0) ? 0 : red));               
                result[x, y].G = (byte)((green > 255) 
                               ? 255 : ((green < 0) ? 0 : green));
                result[x, y].B = (byte)((blue > 255) 
                               ? 255 : ((blue < 0) ? 0 : blue));
                result[x, y].A = (byte)((alpha > 255) 
                               ? 255 : ((alpha < 0) ? 0 : alpha));
            }
        }
        return result;
    }
