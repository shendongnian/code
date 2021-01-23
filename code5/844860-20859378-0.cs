        public void objChecked(Control c, bool enabled)
        {
            Expression property
                = Expression.Property(Expression.Constant(c), "Checked");
            var lambda = Expression.Lambda<Action>(
                             Expression.Assign(
                                 property,
                                 Expression.Constant(enabled)))
                         .Compile();
             if (c.InvokeRequired)
             {
                 BeginInvoke(new MyDelegate(delegate()
                     {
                         lambda.Invoke();
                     }));
             }
             else
             {
                 lambda.Invoke();
             }
        }
