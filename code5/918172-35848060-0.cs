        public void CompleteAdding()
        {
            int num;
            this.CheckDisposed();
            if (this.IsAddingCompleted)
            {
                return;
            }
            SpinWait wait = new SpinWait();
        Label_0017:
            num = this.m_currentAdders;
            if ((num & -2147483648) != 0)
            {
                wait.Reset();
                while (this.m_currentAdders != -2147483648)
                {
                    wait.SpinOnce();
                }
            }
            else if (Interlocked.CompareExchange(ref this.m_currentAdders, num | -2147483648, num) == num)
            {
                wait.Reset();
                while (this.m_currentAdders != -2147483648)
                {
                    wait.SpinOnce();
                }
                if (this.Count == 0)
                {
                    this.CancelWaitingConsumers();
                }
                this.CancelWaitingProducers();
            }
            else
            {
                wait.SpinOnce();
                goto Label_0017;
            }
        }
