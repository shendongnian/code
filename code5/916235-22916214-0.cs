            string Parsers = "...";
            string TemplateN = "...";
            string MethodName = "...";
            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == Parsers && t.Name == TemplateN
                    select t;
            Type classType = null;
            foreach (var item in q)
            {
                classType = item;//select the first match
                break;
            }
            if (classType == null)
            {
                return; //no matched class
            }
            MethodInfo mf = classType.GetMethod(MethodName);
            if (mf  == null)
            {
                return; //no matched method
            }
            myOrderDraft = mf.Invoke(new object()/*Sender*/,new object[]{}/*parameters*/);
