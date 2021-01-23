        private abstract class Base1
        {
        }
        private class Extend1 : Base1
        {
            
        }
            Base1 whatTypeAmI = new Extend1();
            var t = whatTypeAmI.GetType();
            switch (t)
            {
                case: typeof(Extend1)
                {
                    //the code gets in here, do work!
                    break;
                }
            }
