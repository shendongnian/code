    class FieldEnumerator : IEnumerable<Field>
    {
        Field[,] array;
        public FieldEnumerator(Field[,] array)
        {
            this.array = array;
        }
        public IEnumerator<Field> GetEnumerator()
        {
            for (int i = 0; i < this.array.GetLength(0); ++i)
                for (int j = 0; j < this.array.GetLength(1); ++j)
                {
                    yield return this.array[i, j];
                }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
