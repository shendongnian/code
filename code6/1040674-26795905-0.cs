    //DetectCombination like this:
        public DateTime PrevPress { get; set; }
        public DateTime CurrentPress { get; set; }
        public string PrevKey { get; set; }
        private void SEND_KeyPress(object sender, KeyPressEventArgs e)
        {
            string keycomb = DetectCombination(e.KeyChar.toString);
        }
        public string DetectCombination(string currentKey)
        {
            CurrentPress = DateTime.Now;
            if(CurrentPress.CompareTo(PrevPress) < //100ms)
            {
                PrevKey+=currentKey;
            }
            else
            {
                PrevKey = currentKey;
                PrevPress = CurrentPress;
            }
            return PrevKey;
        }
