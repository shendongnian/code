    public String unicode
        {
            get
            {
                String codePoint = this.code.Substring(2); // remove '\u' => "f164";
                int unicode = int.Parse(codePoint, System.Globalization.NumberStyles.HexNumber);
                String unicodeString = char.ConvertFromUtf32(unicode).ToString();
                return unicodeString; // "\uf164"
            }
        }
