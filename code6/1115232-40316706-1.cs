        public CP:ContentPage
        {
            //....
            public CP()
            {
                this.Appearing += CP_Appearing ;
                //...
            }
            private void CP_Appearing(object sender, EventArgs e)
            {
                Debug.WriteLine("*************HALLO******WELCOME BACK.");
            }
        }
        
