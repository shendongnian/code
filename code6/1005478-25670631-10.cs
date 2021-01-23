    public class Label
    {
        #region Print logic. Taken from http://support.microsoft.com/kb/322091
        //Snip stuff unchanged from the KB example.   
        [DllImport("winspool.Drv", EntryPoint="WritePrinter", SetLastError=true, ExactSpelling=true, CallingConvention=CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, byte[] pBytes, Int32 dwCount, out Int32 dwWritten );     
        private static bool SendBytesToPrinter(string szPrinterName, byte[] Bytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false;
            di.pDocName = "Zebra Label";
            di.pDataType = "RAW";
            
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    if (StartPagePrinter(hPrinter))
                    {
                        bSuccess = WritePrinter(hPrinter, Bytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
                throw new Win32Exception(dwError);
            }
            return bSuccess;
        }
        #endregion
        public byte[] CreateCompleteCommand(bool headerAndFooter)
        {
            List<byte> byteCollection = new List<byte>();
            //Static header content describing the label.
            if (headerAndFooter)
            {
                byteCollection.AddRange(Encoding.ASCII.GetBytes("\nN\n"));
                byteCollection.AddRange(Encoding.ASCII.GetBytes(String.Format("S{0}\n", this.Speed)));
                byteCollection.AddRange(Encoding.ASCII.GetBytes(String.Format("D{0}\n", this.Density)));
                byteCollection.AddRange(Encoding.ASCII.GetBytes(String.Format("q{0}\n", this.LabelHeight)));
                if (this.AdvancedLabelSizing)
                {
                    byteCollection.AddRange(Encoding.ASCII.GetBytes(String.Format("Q{0},{1}\n", this.LableLength, this.GapLength)));
                }
            }
            //The content of the label.
            foreach (var command in this.Commands)
            {
                byteCollection.AddRange(command.GenerateByteCommand());
            }
            //The footer content of the label.
            if(headerAndFooter)
                byteCollection.AddRange(Encoding.ASCII.GetBytes(String.Format("P{0}\n", this.Pages)));
            return byteCollection.ToArray();
        }
        public bool PrintLabel(string printer)
        {
            byte[] command = this.CreateCompleteCommand(true);
            return SendBytesToPrinter(printer, command, command.Length); 
        }
        public List<Epl2CommandBase> Commands { get; private set; }
        //Snip rest of the code.
    }
    public abstract partial class Epl2CommandBase
    {
        protected Epl2CommandBase() { }
        public virtual byte[] GenerateByteCommand()
        {
            return Encoding.ASCII.GetBytes(CommandString + '\n');
        }
        public abstract string CommandString { get; set; }
    }
    public class Text : Epl2CommandBase 
    {
        public override string CommandString
        {
            get
            {
                string printText = TextValue;
                if (Font == Fonts.Pts24)
                    printText = TextValue.ToUpperInvariant();
                printText = printText.Replace("\\", "\\\\"); // Replace \ with \\
                printText = printText.Replace("\"", "\\\""); // replace " with \"
                return String.Format("A{0},{1},{2},{3},{4},{5},{6},\"{7}\"", X, Y, (byte)TextRotation, (byte)Font, HorziontalMultiplier, VertricalMultiplier, Reverse, printText);
            }
            set
            {
                GenerateCommandFromText(value);
            }
        }
        private void GenerateCommandFromText(string command)
        {
            if (!command.StartsWith(GetFactoryKey()))
                throw new ArgumentException("Command must begin with " + GetFactoryKey());
            string[] commands = command.Substring(1).Split(',');
            this.X = int.Parse(commands[0]);
            this.Y = int.Parse(commands[1]);
            this.TextRotation = (Rotation)byte.Parse(commands[2]);
            this.Font = (Fonts)byte.Parse(commands[3]);
            this.HorziontalMultiplier = int.Parse(commands[4]);
            this.VertricalMultiplier = int.Parse(commands[5]);
            this.ReverseImageColor = commands[6].Trim().ToUpper() == "R";
            string message = String.Join(",", commands, 7, commands.Length - 7);
            this.TextValue = message.Substring(1, message.Length - 2); // Remove the " at the beginning and end of the string.
        }
        //Snip
    }
