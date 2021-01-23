    private void PleaseWalk(object obj)
        {
            string Method = "Walk";
            MethodInfo walkMethod = obj.GetType().GetMethod(Method, Type.EmptyTypes, null);
            if (walkMethod != null)
            {
                walkMethod.Invoke(obj, new object[] { });
            }
            else
            {
                Console.WriteLine(string.Format("I can not {0} because {1}", Method, WhoAreYou(obj)));
            }
        }
        private string WhoAreYou(object unknown)
        {
            MethodInfo whoAreYou = unknown.GetType().GetMethod("WhoAreYou", Type.EmptyTypes, null);
            return whoAreYou.Invoke(unknown, new object[] { }).ToString();
        }
