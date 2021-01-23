    private void Calc(int i, int j, int k = 60, int l = 80)
        {
            var parameters =
                System.Reflection.MethodInfo.GetCurrentMethod().GetParameters().Where(param => param.HasDefaultValue);
          //parameters = {k, l}
        }
