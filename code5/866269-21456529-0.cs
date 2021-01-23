    public void Forward(string Path,string Name,List<string> AttributeName = null,List<string> AttributeValue = null,string Value = null, int NumberOfNames = 1,bool EndA = true,bool EndB = true)
    {
            <codes>
            */if (!AttributeName.Equals(null) || AttributeName.Equals(""))
            {
                var Text1 = AttributeName;
                var Text2 = AttributeValue;
                var BothText = Text1.Zip(Text2, (t1, t2) => new { Word1 = t1, Word2 = t2 });
                foreach (var tt in BothText)
                {
                    Lab.SaveAttribute(tt.Word1, tt.Word2);
                }
            }
         **/if (!Value.Equals(null) || Value.Equals(""))
            {
                <codes>
            }
            if (EndA)
            {
                <codes>
            }
            if (EndB)
            {
                <codes>
            }
    }
