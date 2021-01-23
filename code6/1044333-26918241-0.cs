        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj,null))
            {
                return false;
            }
            if (ReferenceEquals(this,obj))
            {
                return true;
            }
            if (this.GetType() != obj.GetType())
            {
                return false;
            }
            product other = (product)obj;
            if (idProduct != other.idProduct)
            {
                return false;
            }
            return true;
        }
