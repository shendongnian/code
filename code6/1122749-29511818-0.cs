    string RemoveDiacritics(string stIn)
        {
            var stFormD = stIn.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            for (var ich = 0; ich < stFormD.Length; ich++)
            {
                var uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                    sb.Append(stFormD[ich]);
            }
            return (sb.ToString().Normalize(NormalizationForm.FormC));
        }
