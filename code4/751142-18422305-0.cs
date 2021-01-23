     public class MultiHttp
    {
        public static string UserAgent = "Mozilla 5.0";
        public static string Header = "Content-Type: application/x-www-form-urlencoded; charset=UTF-8";
        private static string[] Result;
        public static string[] MultiPost(string[] Url, string post, int timeOut)
        {
            Result = new string[post.Length];           
            try
            {
                Curl.GlobalInit((int)CURLinitFlag.CURL_GLOBAL_ALL);
                Easy.WriteFunction wf = new Easy.WriteFunction(OnWriteData);
                //Easy.HeaderFunction hf = new Easy.HeaderFunction(OnHeaderData);
                Easy[] easy = new Easy[Url.Length];
                Multi multi = new Multi();
                for (int i = 0; i < Url.Length; i++)
                {
                    if (Url[i] != null)
                    {
                        easy[i] = new Easy();
                        easy[i].SetOpt(CURLoption.CURLOPT_URL, Url[i]);
                        easy[i].SetOpt(CURLoption.CURLOPT_WRITEFUNCTION, wf);
                        easy[i].SetOpt(CURLoption.CURLOPT_WRITEDATA, i);
                        //easy[i].SetOpt(CURLoption.CURLOPT_HEADERFUNCTION, hf);
                        //easy[i].SetOpt(CURLoption.CURLOPT_HEADERDATA, i);
                        easy[i].SetOpt(CURLoption.CURLOPT_TIMEOUT, timeOut);
                        easy[i].SetOpt(CURLoption.CURLOPT_USERAGENT, UserAgent);
                        Slist sl = new Slist();
                        sl.Append(Header);
                        easy[i].SetOpt(CURLoption.CURLOPT_HTTPHEADER, sl);
                        easy[i].SetOpt(CURLoption.CURLOPT_POSTFIELDS, post);
                        easy[i].SetOpt(CURLoption.CURLOPT_FOLLOWLOCATION, true);
                        easy[i].SetOpt(CURLoption.CURLOPT_POST, true);
                        //easy[i].SetOpt(CURLoption.CURLOPT_NOBODY, true);
                        if (Url[i].Contains("https"))
                        {
                            easy[i].SetOpt(CURLoption.CURLOPT_SSL_VERIFYHOST, 1);
                            easy[i].SetOpt(CURLoption.CURLOPT_SSL_VERIFYPEER, 0);
                        }
                        multi.AddHandle(easy[i]);
                    }
                }
                int stillRunning = 1;
                while (multi.Perform(ref stillRunning) == CURLMcode.CURLM_CALL_MULTI_PERFORM) ;
                while (stillRunning != 0)
                {
                    multi.FDSet();
                    int rc = multi.Select(1000); // one second
                    switch (rc)
                    {
                        case -1:
                            stillRunning = 0;
                            break;
                        case 0:
                        default:
                            {
                                while (multi.Perform(ref stillRunning) == CURLMcode.CURLM_CALL_MULTI_PERFORM) ;
                                break;
                            }
                    }
                }
                // various cleanups
                multi.Cleanup();
                for (int i = 0; i < easy.Length; i++)
                {
                    easy[i].Cleanup();
                }
                Curl.GlobalCleanup();
            }
            catch (Exception)
            {
                //r = ex+"";
            }
            return Result;
        }
        public static Int32 OnWriteData(Byte[] buf, Int32 size, Int32 nmemb,
            Object extraData)
        {
            int tmp = Convert.ToInt32(extraData.ToString()); ;
            Result[tmp] += System.Text.Encoding.UTF8.GetString(buf);
            return size * nmemb;
        }       
    }
