        public void SendContentToMainThread()
        {
            SomeContent content = new SomeContent
            {
                ValueOne = "Hello",
                ValueTwo = "World"
            };
            Action<SomeContent>  myDel = ContentDelagate;//Property Get 
            myDel(content);//invoke delegate
            Console.WriteLine(content.ValueOne);//refer to this below
        }
