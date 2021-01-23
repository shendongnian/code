        static int GetNumOfDigits(decimal dTest)
        {
            int nAnswer = 0;
            dTest = Math.Abs(dTest);
            //For loop version
            for (nAnswer = 0; nAnswer < 29 && dTest > 1; ++nAnswer)
            {
                dTest *= 0.1M;
            }
            //While loop version
            //while (dTest > 1)
            //{
            //    nAnswer++;
            //    dTest *= 0.1M;
            //}
            return (nAsnwer);
        }
