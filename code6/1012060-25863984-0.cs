            public ICollection<LineItem> LineItems 
            {
                get 
                { 
                    return new ReadOnlyCollection<LineItem>(lineItems); 
                } 
            }
