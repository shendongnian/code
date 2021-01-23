    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication7
    {
        class Program
        {
            static void Main(string[] args)
            {
                var str = "Kolkhoz Imeni Il’icha";
    
                Console.WriteLine(UnTrans1(str));
                Console.WriteLine(UnTrans2(str));
    
                var count = 1000000;
    
                var sw = Stopwatch.StartNew();
    
                for (int i = 0; i < count; ++i)
                {
                    UnTrans1(str);
                }
    
                Console.WriteLine(sw.ElapsedMilliseconds);
    
                sw = Stopwatch.StartNew();
    
                for (int i = 0; i < count; ++i)
                {
                    UnTrans2(str);
                }
    
                Console.WriteLine(sw.ElapsedMilliseconds);
                
                Console.ReadLine();
            }
    
            static string UnTrans2(string str)
            {
                var sb = Pool<StringBuilder>.Get();
    
                if (sb == null)
                {
                    sb = new StringBuilder();
                }
                else
                {
                    sb.Clear();
                }
    
                for (int i = 0; i < str.Length; i++)
                {
                    var itm = str[i];
                    
                    switch (itm)
                    {
                            // lower
                        case 's':
                        {
                            if (i + 3 < str.Length)
                            {
                                if (str[i + 1] == 'h')
                                {
                                    if (str[i + 2] == 'c' && str[i + 3] == 'h')
                                    {
                                        sb.Append('щ');
    
                                        i += 3;
    
                                        break;
                                    }
    
                                    i += 1;
    
                                    sb.Append('ч');
    
                                    break;
                                }
    
                                sb.Append('с');
    
                                break;
                            }
    
                            if (i + 1 < str.Length)
                            {
                                if (str[i + 1] == 'h')
                                {
                                    i += 1;
    
                                    sb.Append('ч');
    
                                    break;
                                }
                            }
    
                            sb.Append('с');
    
                            break;
                        }
                        case 'y':
                        {
                            if (i + 1 < str.Length)
                            {
                                switch (str[i+1])
                                {
                                    case 'a':
                                    {
                                        i += 1;
    
                                        sb.Append('я');
    
                                        continue;
                                    }
                                    case 'e':
                                    {
                                        i += 1;
    
                                        sb.Append('е');
    
                                        continue;
                                    }
                                    case 'u':
                                    {
                                        i += 1;
    
                                        sb.Append('ю');
    
                                        continue;
                                    }
                                    case 'ë':
                                    {
                                        i += 1;
    
                                        sb.Append('ё');
    
                                        continue;
                                    }
                                }
                            }
    
                            sb.Append('ы');
    
                            break;
                        }
                        case 'z':
                        {
                            if (i + 1 < str.Length && str[i + 1] == 'h')
                            {
                                i += 1;
    
                                sb.Append('ж');
    
                                break;
                            }
    
                            sb.Append('з');
    
                            break;
                        }
                        case 'k':
                        {
                            if (i + 1 < str.Length && str[i + 1] == 'h')
                            {
                                i += 1;
    
                                sb.Append('х');
    
                                break;
                            }
    
                            sb.Append('к');
    
                            break;
                        }
                        case 'i':
                        {
                            if (i + 1 < str.Length && str[i + 1] == 'y')
                            {
                                i += 1;
    
                                sb.Append('й');
    
                                break;
                            }
    
                            sb.Append('и');
    
                            break;
                        }
                        case 'c':
                        {
                            if (i + 1 < str.Length && str[i + 1] == 'h')
                            {
                                i += 1;
    
                                sb.Append('ч');
    
                                break;
                            }
    
                            sb.Append('с');
    
                            break;
                        }
                        case 'f':
                        {
                            sb.Append('ф');
                            
                            break;
                        }
                        case 'u':
                        {
                            sb.Append('у');
    
                            break;
                        }
                        case 't':
                        {
                            sb.Append('т');
    
                            break;
                        }
                        case 'r':
                        {
                            sb.Append('р');
    
                            break;
                        }
                        case 'p':
                        {
                            sb.Append('п');
    
                            break;
                        }
                        case 'o':
                        {
                            sb.Append('о');
    
                            break;
                        }
                        case 'n':
                        {
                            sb.Append('н');
    
                            break;
                        }
                        case 'm':
                        {
                            sb.Append('м');
    
                            break;
                        }
                        case 'l':
                        {
                            sb.Append('л');
    
                            break;
                        }
                        case 'd':
                        {
                            sb.Append('д');
    
                            break;
                        }
                        case 'g':
                        {
                            sb.Append('г');
    
                            break;
                        }
                        case 'v':
                        {
                            sb.Append('в');
    
                            break;
                        }
                        case 'b':
                        {
                            sb.Append('б');
    
                            break;
                        }
                        case 'a':
                        {
                            sb.Append('а');
    
                            break;
                        }
                        case '’':
                        case '\'':
                        {
                            sb.Append('ь');
    
                            break;
                        }
                        case '”':
                        case '\"':
                        {
                            sb.Append('ъ');
    
                            break;
                        }
                        case 'e':
                        {
                            sb.Append('e');
    
                            break;
                        }
                            // upper
                        case 'S':
                        {
                            if (i + 3 < str.Length)
                            {
                                if (str[i + 1] == 'h')
                                {
                                    if (str[i + 2] == 'c' && str[i + 3] == 'h')
                                    {
                                        i += 3;
    
                                        sb.Append('Щ');
    
                                        break;
                                    }
    
                                    i += 1;
    
                                    sb.Append('Ч');
    
                                    break;
                                }
    
                                sb.Append('С');
    
                                break;
                            }
    
                            if (i + 1 < str.Length)
                            {
                                if (str[i + 1] == 'h')
                                {
                                    i += 1;
    
                                    sb.Append('Ч');
    
                                    break;
                                }
                            }
    
                            sb.Append('С');
    
                            break;
                        }
                        case 'Y':
                        {
                            if (i + 1 < str.Length)
                            {
                                switch (str[i + 1])
                                {
                                    case 'a':
                                        {
                                            i += 1;
    
                                            sb.Append('Я');
    
                                            continue;
                                        }
                                    case 'e':
                                        {
                                            i += 1;
    
                                            sb.Append('Е');
    
                                            continue;
                                        }
                                    case 'u':
                                        {
                                            i += 1;
    
                                            sb.Append('Ю');
    
                                            continue;
                                        }
                                    case 'ë':
                                        {
                                            i += 1;
    
                                            sb.Append('Ё');
    
                                            continue;
                                        }
                                }
                            }
    
                            sb.Append('Ы');
    
                            break;
                        }
                        case 'Z':
                        {
                            if (i + 1 < str.Length && str[i + 1] == 'h')
                            {
                                i += 1;
    
                                sb.Append('Ж');
    
                                break;
                            }
    
                            sb.Append('З');
    
                            break;
                        }
                        case 'K':
                        {
                            if (i + 1 < str.Length && str[i + 1] == 'h')
                            {
                                i += 1;
    
                                sb.Append('Х');
    
                                break;
                            }
    
                            sb.Append('К');
    
                            break;
                        }
                        case 'I':
                        {
                            if (i + 1 < str.Length && str[i + 1] == 'y')
                            {
                                i += 1;
    
                                sb.Append('Й');
    
                                break;
                            }
    
                            sb.Append('И');
    
                            break;
                        }
                        case 'C':
                        {
                            if (i + 1 < str.Length && str[i + 1] == 'h')
                            {
                                i += 1;
    
                                sb.Append('Ч');
    
                                break;
                            }
    
                            sb.Append('С');
    
                            break;
                        }
                        case 'F':
                        {
                            sb.Append('Ф');
    
                            break;
                        }
                        case 'U':
                        {
                            sb.Append('У');
    
                            break;
                        }
                        case 'T':
                        {
                            sb.Append('Т');
    
                            break;
                        }
                        case 'R':
                        {
                            sb.Append('Р');
    
                            break;
                        }
                        case 'P':
                        {
                            sb.Append('Н');
    
                            break;
                        }
                        case 'O':
                        {
                            sb.Append('О');
    
                            break;
                        }
                        case 'N':
                        {
                            sb.Append('Н');
    
                            break;
                        }
                        case 'M':
                        {
                            sb.Append('М');
    
                            break;
                        }
                        case 'L':
                        {
                            sb.Append('Л');
    
                            break;
                        }
                        case 'D':
                        {
                            sb.Append('Д');
    
                            break;
                        }
                        case 'G':
                        {
                            sb.Append('Г');
    
                            break;
                        }
                        case 'V':
                        {
                            sb.Append('В');
    
                            break;
                        }
                        case 'B':
                        {
                            sb.Append('Б');
    
                            break;
                        }
                        case 'A':
                        {
                            sb.Append('А');
    
                            break;
                        }
                        case 'E':
                        {
                            sb.Append('Э');
    
                            break;
                        }
                        default :
                        {
                            sb.Append(itm);
    
                            break;
                        }
                    }
                }
    
                Pool<StringBuilder>.Release(sb);
    
                return sb.ToString();
            }
    
            static string UnTrans1(string str)
            {
                return str.Replace("shch", "щ")//
                          .Replace("Shch", "Щ")//
                          .Replace("ya", "я")//
                          .Replace("Ya", "Я")//
                          .Replace("zh", "ж")//
                          .Replace("Zh", "Ж")//
                          .Replace("Ye", "Е")//
                          .Replace("ye", "е")//
                          .Replace("yu", "ю")//
                          .Replace("Yu", "Ю")//
                          .Replace("Sh", "Ш")//
                          .Replace("sh", "ш")//
                          .Replace("kh", "х")//
                          .Replace("Kh", "Х")//
                          .Replace("iy", "й")//
                          .Replace("Iy", "Й")//
                          .Replace("Yë", "Ё")//
                          .Replace("yë", "ё")//
                          .Replace("Ch", "Ч")//
                          .Replace("ch", "ч")//
                          .Replace("F", "Ф")//
                          .Replace("f", "ф")//
                          .Replace("u", "у")//
                          .Replace("U", "У")//
                          .Replace("T", "Т")
                          .Replace("t", "т")
                          .Replace("S", "С")//
                          .Replace("s", "с")//
                          .Replace("R", "Р")
                          .Replace("r", "р")
                          .Replace("P", "П")
                          .Replace("p", "п")
                          .Replace("O", "О")
                          .Replace("o", "о")
                          .Replace("N", "Н")
                          .Replace("n", "н")
                          .Replace("M", "М")
                          .Replace("m", "м")
                          .Replace("L", "Л")
                          .Replace("l", "л")
                          .Replace("K", "К")//
                          .Replace("k", "к")//
                          .Replace("I", "И")//
                          .Replace("i", "и")//
                          .Replace("Z", "З")//
                          .Replace("z", "з")//
                          .Replace("D", "Д")
                          .Replace("d", "д")
                          .Replace("G", "Г")
                          .Replace("g", "г")
                          .Replace("V", "В")
                          .Replace("v", "в")
                          .Replace("B", "Б")
                          .Replace("b", "б")
                          .Replace("A", "А")
                          .Replace("a", "а")
                          .Replace("’", "ь")
                          .Replace("”", "ъ")
                          .Replace("\"", "ъ")
                          .Replace("Y", "Ы")//
                          .Replace("y", "ы")//
                          .Replace("'", "ь")
                          .Replace("E", "Э")
                          .Replace("e", "е");
            }
        }
    
        public static class Pool<T> where T : class
        {
            static Dictionary<int, Dictionary<Type, Queue<T>>> ht;
            static ValueLock locker;
    
            static Pool()
            {
                ht = new Dictionary<int, Dictionary<Type, Queue<T>>>(256);
                locker = new ValueLock();
            }
    
            public static T Get()
            {
                var idt = System.Threading.Thread.CurrentThread.ManagedThreadId;
    
                Dictionary<Type, Queue<T>> dic;
    
                if (!ht.ContainsKey(idt))
                {
                    dic = new Dictionary<Type, Queue<T>>();
    
                    locker.Lock();
    
                    ht.Add(idt, dic);
    
                    locker.Unlock();
                }
                else
                {
                    dic = ht[idt];
                }
    
                T obj = null;
    
                if (dic.ContainsKey(typeof(T)))
                {
                    var q = dic[typeof(T)];
    
                    if (q.Count > 0)
                    {
                        obj = q.Dequeue();
                    }
                }
    
                return obj;
            }
    
            public static void Release(T obj)
            {
                var idt = System.Threading.Thread.CurrentThread.ManagedThreadId;
    
                Dictionary<Type, Queue<T>> dic;
    
                if (!ht.ContainsKey(idt))
                {
                    dic = new Dictionary<Type, Queue<T>>();
    
                    locker.Lock();
    
                    ht.Add(idt, dic);
    
                    locker.Unlock();
                }
                else
                {
                    dic = ht[idt];
                }
    
                Queue<T> q;
    
                if (dic.ContainsKey(typeof(T)))
                {
                    q = dic[typeof(T)];
                }
                else
                {
                    q = new Queue<T>();
    
                    dic.Add(typeof(T), q);
                }
    
                q.Enqueue(obj);
            }
        }
    
        public class ValueLock
        {
            const long maxTime = 100;
            int val;
            long time;
    
            public ValueLock()
            {
                val = 0;
                time = 0;
            }
    
            public void Lock()
            {
                var cur = Thread.CurrentThread.ManagedThreadId;
    
                if (cur == val)
                {
                    return;
                }
    
                while (true)
                {
                    if (val == 0)
                    {
                        if (Interlocked.CompareExchange(ref val, cur, 0) == 0)
                        {
                            time = DateTime.Now.Ticks;
    
                            return;
                        }
                    }
    
                    if ((DateTime.Now.Ticks - time) / TimeSpan.TicksPerMillisecond > maxTime)
                    {
                        var tmp = val;
    
                        // unlock
                        if (Interlocked.CompareExchange(ref val, cur, tmp) == tmp)
                        {
                            time = DateTime.Now.Ticks;
    
                            return;
                        }
                    }
    
                    Thread.Yield();
                }
            }
    
            public void Unlock()
            {
                val = 0;
            }
        }
    }
