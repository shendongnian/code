    public override int GetHashCode()
    {
        unchecked
        {                
            var result = this.ProdID.GetHashCode();
            result = (result * 397) ^ this.CategoryID;
            return result;
        }
    }
