            foreach (var paramVar in vars)
            {
                var value = Request.Params.Get(paramVar);
                if (!string.IsNullOrEmpty(value))
                {
                    Log.Error("\nparam:" + paramVar);
                }
            }
