            public override LabTest CreateTest(Enum e)
            {
                BloodTest bt = null;
                if(!e.GetType.Equals(typeof(BloodTestType)))
                {
                   // throw type exception of your choice
                }
            }
