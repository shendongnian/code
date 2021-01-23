            var weights = new List<Weights>();
            weights.Add(new Weights());
            var debugWeights = CreateSerializedCopy<List<Weights>>(weights);
            if (debugWeights[0] == weights[0])
            {
                System.Diagnostics.Debug.WriteLine("Did not serialize correctly");
            }
