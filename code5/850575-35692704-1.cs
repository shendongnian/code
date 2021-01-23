    class BarcodeReader
    {
        ArrayList barCode = new ArrayList();
        ArrayList barCodeTimes = new ArrayList();
        ArrayList barCodeDeltaTimes = new ArrayList();
        /// <summary>
        /// Input 1: delayTime (ms) - time for scanner to return values (threshold)[30 seems good],
        /// Input 2: KeyEventArgs - put in key [this.KeyDown += new KeyEventHandler(Form1_KeyDown)],
        /// Output 1: String of barcode read
        /// </summary>
        /// <param name="delayTime"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public string BarcodeValue(int delayTime, KeyEventArgs e)
        {
            string barCodeString = null;
            var isNumber = e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9;
            var rtn = e.KeyCode == Keys.Enter;
            if (isNumber)
            {
                barCode.Add(Encoding.ASCII.GetString(new byte[] { (byte)e.KeyValue }));
                barCodeTimes.Add(DateTime.Now.TimeOfDay.TotalMilliseconds);
            }
            if (rtn)
            {
                barCodeString = ValuesToString(delayTime);
            }
            return barCodeString;
        }
        private string ValuesToString(int delayTime)
        {
            string barCodeString = null;
            foreach (double d in barCodeTimes)
            {
                double diff = 0;
                int index = barCodeTimes.IndexOf(d);
                if (index < barCodeTimes.Count - 1)
                {
                    diff = (double)barCodeTimes[index + 1] - (double)barCodeTimes[index];
                }
                barCodeDeltaTimes.Add(diff);
            }
            foreach (double d in barCodeDeltaTimes)
            {
                if (d > delayTime)
                {
                    barCode.RemoveAt(0);
                }
            }
            foreach (string s in barCode)
            {
                barCodeString += s;
            }
            barCode.Clear();
            barCodeTimes.Clear();
            barCodeDeltaTimes.Clear();
            return barCodeString;
        }
    }
