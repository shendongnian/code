    public static class MyDataFactory
    {
        public static MyData Create()
        {
            var myData = new MyData();
            DataUtilities.ApplyAttributes(myData);
            return myData;
        }
    }
