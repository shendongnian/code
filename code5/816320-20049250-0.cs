            var readonlyGlobalBinding = new Binding
                {
                    Source = myRoot, // to fill
                    Path = new PropertyPath(IsGlobalReadOnlyProperty)
                };
            var be = box.GetBindingExpression(TextBoxBase.IsReadOnlyProperty);
            if (be != null)
            {
                var mb = new MultiBinding();
                mb.Bindings.Add(be.ParentBinding);
                mb.Bindings.Add(readonlyGlobalBinding);
                mb.Converter = new OrConverter();
                box.SetBinding(TextBoxBase.IsReadOnlyProperty, mb);
            }else if(!box.IsReadOnly)
                box.SetBinding(TextBoxBase.IsReadOnlyProperty, readonlyGlobalBinding);
