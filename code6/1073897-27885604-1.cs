        public static Random generate = new Random();
        
        public String IMEICode()
            {
                int[] code = new int[14];
                int format = FormatCombo.SelectedIndex;
                StringBuilder IMEI = new StringBuilder();
                ... //irrelevant
                for (int i = 0; i < code.Length; i++)
                {
                    code[i] = generate.Next(10);
                }
                ... //irrelevant
                return IMEI.ToString();
            }
        
        public String IMEICode2()
            {
                int[] code2 = new int[14];
                int format = FormatCombo.SelectedIndex;
                StringBuilder IMEI2 = new StringBuilder();
                ... //irrelevant
                for (int i = 0; i < code2.Length; i++)
                {
                    code2[i] = generate2.Next(10);
                }
                ... //irrelevant
                return IMEI2.ToString();
            }
