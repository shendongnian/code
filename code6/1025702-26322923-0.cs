        public static void Main(string[] args)
        {
            try
            {
                while (infinity) {
                    var sCard = new WinSCard();
                    sCard.EstablishContext();                   //establis smart card reader resourete manager
                    sCard.ListReaders();                        //get list of smart card reader
