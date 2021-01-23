    public override bool Equals(object obj)
    {
        if (obj is TypeYouAreExpecting)
        {
            TypeYouAreExpecting other = (TypeYouAreExpecting) obj;
            bool areEqual = false;
            // implement your equals logic here
            return areEqual;
        }
        return base.Equals(obj);
    }
