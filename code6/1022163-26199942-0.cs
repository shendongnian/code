        private void ReheapDown(int index)
        {
            bool Terminate;
            int Processing = index,
                Largest = -1;
            do
            {
                Terminate = true;
                int LeftChild = CLEFT(Processing),
                    RightChild = CRIGHT(Processing);
                if (LeftChild <= _LastUsed)
                {
                    Largest = LeftChild;
                    if (RightChild <= _LastUsed && _Data[Largest].CompareTo(_Data[RightChild]) < 0)
                        Largest = RightChild;
                    if (_Data[Processing].CompareTo(_Data[Largest]) < 0)
                    {
                        Utility.Swap(ref _Data[Processing], ref _Data[Largest]);
                        Terminate = false;
                        Processing = Largest;
                    }
                }
            } while (!Terminate);
        }
