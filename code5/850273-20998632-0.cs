        private Payment SortPayments(params Payment[] payments)
        {
            for (int i = 0; i < payments.Length - 1; i++)
            {
                if (payments[i + 1] != null)
                {
                    payments[i].SupplementalPayment = payments[i + 1];
                }
                else
                {
                    int j = 1;
                    while (true)
                    {
                        if (payments[i + j] == null)
                        {
                            j++;
                        }
                        else
                        {
                            payments[i].SupplementalPayment = payments[i + j];
                            i += j;
                        }
                    }
                }
            }
            return payments[0];
        }
