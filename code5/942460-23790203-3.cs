        static BigInteger IterativeLucas(BigInteger a, BigInteger Q, BigInteger N)
        {
            BigInteger[] acc = new BigInteger[2];
            Action<BigInteger> push = (el) => {
                    acc[1] = acc[0];
                    acc[0] = el;
            };
            for (BigInteger i = 0; i <= Q; i++)
            {
                if (i == 0)
                {
                    push(1);
                }
                else if (i == 1)
                {
                    push(a);
                }
                else
                {
                    BigInteger q_1 = acc[0];
                    BigInteger q_2 = acc[1];
                    push((2 * a * q_1 - q_2) % N);
                }
            }
            return acc[0];
        }
