            srPlik = new StreamReader(sFel, System.Text.Encoding.ASCII, false, 512); //dluzszy ciag znakow niz string czyli 256
            do
            {
                sLinia = srPlik.ReadLine();
                i=sLinia.IndexOf(",",13);
                string kwota  = sLinia.Substring( 13,i-13);
            
                dKwota_3 = Convert.ToDecimal(kwota)/100; 
                this.tb3.Text = dKwota_3.ToString();
                int j = sLinia.IndexOf(",", i+1);
                string  nr_rozl_odd_nad  = sLinia.Substring( i+1,j-i-1);
                    
                    
                     int k=sLinia.IndexOf(",", j+1);
                     string nr_rozl_odd_odb = sLinia.Substring(j + 1, k - j - 1);
                     int l = sLinia.IndexOf(",", k + 1);
                     string rach_klienta_nadawcy = sLinia.Substring(k + 1, l - k - 1);
                     int m = sLinia.IndexOf(",", l + 1);
                     string rach_klienta_adresata = sLinia.Substring(l + 1, m - l - 1);
                     int n = sLinia.IndexOf(",", m + 1);
                     string nazwaiadres = sLinia.Substring(m + 1, n - m - 1);
                     int o = sLinia.IndexOf(",", n + 1);
                     string s9 = sLinia.Substring(n + 1, o - n - 1);
                     int p = sLinia.IndexOf(",", o + 1);
                     string s10 = sLinia.Substring(o + 1, p - o - 1);
                     int r = sLinia.IndexOf(",", p + 1);
                     string s11 = sLinia.Substring(p + 1, r - p - 1);
                   
                    int koniec_tytulu = sLinia.IndexOf('"',r+2); //szukaj cudzysłowia czyli końca tytułu
                    string s12 = sLinia.Substring(r + 1, koniec_tytulu - r -2-1);
                                        
                     int t = sLinia.IndexOf(",", koniec_tytulu + 2);
                    string s13 = sLinia.Substring(koniec_tytulu + 2, t - koniec_tytulu - 2);
                    int u = sLinia.IndexOf(",", t + 1);
                    string s14 = sLinia.Substring(u + 1, u - t - 1);
