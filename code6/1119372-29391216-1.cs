        private EllipsisString FirstName { get; set; }
        public void Method()
        {
            FirstName = "Thomas";
            Console.WriteLine(FirstName);
            Console.WriteLine(FirstName.Value);
        }
