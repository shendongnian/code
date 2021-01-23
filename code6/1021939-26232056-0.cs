      private static string DeleteAccentAndSpecialsChar(string OriginalText)
        {
            string strTemp = OriginalText;
            Regex rega = new Regex("[Ά]");
            Regex rege = new Regex("[Έ]");
            Regex regi = new Regex("[Ί]");
            Regex regu = new Regex("[Ύ]");
            Regex regh = new Regex("[Ή]");
            Regex rego = new Regex("[Ό]");
            Regex regw = new Regex("[Ώ]");
            strTemp = rega.Replace(strTemp, "Α");
            strTemp = rege.Replace(strTemp, "Ε");
            strTemp = regi.Replace(strTemp, "Ι");
            strTemp = regu.Replace(strTemp, "Υ");
            strTemp = regh.Replace(strTemp, "Η");
            strTemp = rego.Replace(strTemp, "Ο");
            strTemp = regw.Replace(strTemp, "Ω");
            return strTemp;
        }
