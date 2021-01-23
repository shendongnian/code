           for (int i = 0; i < YatakList.Count; i++)
            {
                if (YatakList[i].GrupId != Op.yatakGrupId)
                {
                    continue;
                }
                var AllBlanks = YatakList[i].blanks.SelectMany((item, index) => item.Select(entry => new { Index = index, Start = entry.Key, Length = entry.Value, Id = YatakList[i].Id, GrupId = YatakList[i].GrupId })).OrderBy(item => item.Start);
                var LenghtSuitingBlanks = from blank in AllBlanks where (blank.Length >= Op.sure) orderby blank.Start select blank;
                for (int j = 0; j < LenghtSuitingBlanks.Count(); j++)
                {
                    UygunYatak uygunYatak = new UygunYatak();
                    uygunYatak.Id = LenghtSuitingBlanks.ElementAt(j).Id;
                    uygunYatak.GrupId = LenghtSuitingBlanks.ElementAt(j).GrupId;
                    uygunYatak.Start = LenghtSuitingBlanks.ElementAt(j).Start;
                    uygunYatak.Length = LenghtSuitingBlanks.ElementAt(j).Length;
                    
                    UygunYatakList.Add(uygunYatak);
                }
            }
    public class UygunYatak
    {
        public int Id;
        public int GrupId;
        public int Start;
        public int Length;
    }
