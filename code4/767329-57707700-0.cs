        public struct AsyncOutResult<T, OUT>
        {
            T returnValue;
            OUT result;
        
            public AsyncOutResult(T returnValue, OUT result)
            {
                this.returnValue = returnValue;
                this.result = result;
            }
        
            public T Result(out OUT result)
            {
                result = this.result;
                return returnValue;
            }
        }
