        List<List<object>> newList = new List<List<object>>();
        void SplitObj(int objectsPerPart)
        {
            if (BL == null || BL.Count < 1)
                return;
            List<object> current = new List<object>();
            current.Add(BL[0]);
            for (int i = 1; i < BL.Count; i++)
            {
                if (i % objectsPerPart == 0)
                {
                    newList.Add(current);
                    current = new List<object>();
                }
                current.Add(BL[i]);
            }
        }
