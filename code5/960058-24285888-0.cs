        public Nested()
        {
            Type type;
            for (int i = 1;; i++)
            {
                // Get the method in the i'th stack frame
                var method = new StackFrame(i).GetMethod();
                if (method == null) return;
                // Get the class declaring the method
                type = method.DeclaringType;
                if (type == null) return;
                // If the class isn't a parent class, use it.
                if (!type.IsSubclassOf(typeof(Nested)))
                    break;
            }
            _parent = type.FullName;    // Will be set to "Parent"
        }
