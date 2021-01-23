        static int x = 5;
        static int y = 6;
        static int z = 7;
        static public int sum(MyEnum enum1, MyEnum enum2)
        { 
            int a = 0; 
            int b = 0;
            switch (enum1)
            {
                case MyEnum.x:
                    a = x;
                    break;
                case MyEnum.y:
                    a = y;
                    break;
                case MyEnum.z:
                    a = z;
                    break;
                default:
                    break;
            }
            switch (enum2)
            {
                case MyEnum.x:
                    b = x;
                    break;
                case MyEnum.y:
                    b = y;
                    break;
                case MyEnum.z:
                    b = z;
                    break;
                default:
                    break;
            }
            return (a + b);
        }
