    public void WriteName()
    {
            string className = "";
            if (this is DerivedClass)
            {
                className = ((DerivedClass)this).GetName();
            }
            else
            {
                className = this.GetName();
            }
            Console.WriteLine(className);
    }
