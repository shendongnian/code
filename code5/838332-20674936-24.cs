        static string GREEK_SMALL_LETTER_MU = new String(new char[] { '\u03BC' });
        static string MICRO_SIGN = new String(new char[] { '\u00B5' });
        public static void Main()
        {
            string Mus = "µμ";
            string NormalizedString = null;
            int i = 0;
            do
            {
                string OriginalUnicodeString = Mus[i].ToString();
                if (OriginalUnicodeString.Equals(GREEK_SMALL_LETTER_MU))
                    Console.WriteLine(" INFORMATIO ABOUT GREEK_SMALL_LETTER_MU");
                else if (OriginalUnicodeString.Equals(MICRO_SIGN))
                    Console.WriteLine(" INFORMATIO ABOUT MICRO_SIGN");
                Console.WriteLine();
                ShowHexaDecimal(OriginalUnicodeString);                
                Console.WriteLine("Unicode character category " + CharUnicodeInfo.GetUnicodeCategory(Mus[i]));
                NormalizedString = OriginalUnicodeString.Normalize(NormalizationForm.FormC);
                Console.Write("Form C Normalized: ");
                ShowHexaDecimal(NormalizedString);               
                NormalizedString = OriginalUnicodeString.Normalize(NormalizationForm.FormD);
                Console.Write("Form D Normalized: ");
                ShowHexaDecimal(NormalizedString);               
                NormalizedString = OriginalUnicodeString.Normalize(NormalizationForm.FormKC);
                Console.Write("Form KC Normalized: ");
                ShowHexaDecimal(NormalizedString);                
                NormalizedString = OriginalUnicodeString.Normalize(NormalizationForm.FormKD);
                Console.Write("Form KD Normalized: ");
                ShowHexaDecimal(NormalizedString);                
                Console.WriteLine("_______________________________________________________________");
                i++;
            } while (i < 2);
            Console.ReadLine();
        }
        private static void ShowHexaDecimal(string UnicodeString)
        {
            Console.Write("Hexa-Decimal Characters of " + UnicodeString + "  are ");
            foreach (short x in UnicodeString.ToCharArray())
            {
                Console.Write("{0:X4} ", x);
            }
            Console.WriteLine();
        }
