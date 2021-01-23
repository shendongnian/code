     for (int i = 0; i < myList.Count; i++)
            {
                if (i == myList.Count - 1)
                    Assembler.AppendLine(myList[i]);
                else
                {
                    if (myList[i] != null)
                        Assembler.AppendLine("(" + bullet++ + ") " + myList[i]);
                }
            }
