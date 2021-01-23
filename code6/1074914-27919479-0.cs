            for (int i = 0; i < vector.Keys.Count; i++)
            {
                string key = vector.Keys.ElementAt(i);
                vector[key] /= magnitude;
            }
