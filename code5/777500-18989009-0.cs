            const int BILLION = 1000000000;
            const int MILLION = 1000000;
            const int THOUSAND = 1000;
            int a = 1256766123;
            int b;
            string c = string.Empty;
            if (a >= BILLION)
            {
                b = a / BILLION;
                c += b.ToString() + "B";
                a -= (b * BILLION);
            }
            if (a >= MILLION)
            {
                b = a / MILLION;
                if (c != string.Empty)
                    c += " ";
                c += b.ToString() + "M";
                a = a - (b * MILLION);
            }
            if (a >= THOUSAND)
            {
                b = a / THOUSAND;
                if (c != string.Empty)
                    c += " ";
                c += b.ToString() + "T";
            }
