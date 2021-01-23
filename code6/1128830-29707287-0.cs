            public virtual string Text {
            get { ... }
 
            set {
                if (value == null) {
                    value = "";
                }
 
                if (value == Text) {
                    return;
                }
                // omitted remainder
            }
        }
