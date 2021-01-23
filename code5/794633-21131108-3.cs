        public int? FindMode(List<int> sample)
        {
            if (sample == null || sample.Count == 0)
            {
                return null;
            }
            List<int> indices = new List<int>();
            sample.Sort();
            //Calculate the Discrete derivative of the sample and record the indices
            //where it is positive.
            for (int i = 0; i < sample.Count; i++)
            {
                int derivative;
                if (i == sample.Count - 1)
                {
                    //This ensures that there is a positive derivative for the
                    //last item in the sample. Without this, the mode could not
                    //also be the largest value in the sample.
                    derivative = int.MaxValue - sample[i];
                }
                else
                {
                    derivative = sample[i + 1] - sample[i];
                }
                if (derivative > 0)
                {
                    indices.Add(i + 1);
                }
            }
            int maxDerivative = 0, maxDerivativeIndex = -1;
            //Calculate the discrete derivative of the indices, recording its
            //maxima and index.
            for (int i = -1; i < indices.Count - 1; i++)
            {
                int derivative;
                if (i == -1)
                {
                    derivative = indices[0];
                }
                else
                {
                    derivative = indices[i + 1] - indices[i];
                }
                if (derivative > maxDerivative)
                {
                    maxDerivative = derivative;
                    maxDerivativeIndex = i + 1;
                }
            }
            //The mode is then the value of the sample indexed by the
            //index of the largest derivative.
            return sample[indices[maxDerivativeIndex] - 1];
        }
