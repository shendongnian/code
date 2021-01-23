     public int GetDepth()
            {
                if (ParentHeader == null)
                {
                    return 1;
                }
                else return 1 + ParentHeader.GetDepth();
            }
