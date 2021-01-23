var landRecs = _land.MainXList().GetAllItems();
            
var landAltRecs = _land.AlternateYList().GetAllItems();
        internal static IEnumerable<Iint> GetAllItems(this IXList list)
        {
            return GetAllItemsGeneric<Iint, IXList>(list);
        }
        internal static IEnumerable<string> GetAllItems(this IYList list)
        {
            return GetAllItemsGeneric<string, IYList>(list);
        }                                                                                                                                   
        private static IEnumerable<Zout> GetAllItemsGeneric<Zout, T>(T list)
            where Zout : class      // (string -or- int)  -or-  (IReadOnlyTxnMisc or ITxnMisc) etc.
            where T : class         // IYList  -or- IXList  
        {
            try
            {
                DoHeadforList<T>(list);
            }
            catch (Exception)
            {
                yield break;
            }
            Guid guid = Marshal.GenerateGuidForType(typeof(Zout));
            do
            {
                Zout rec = null;
                try
                {
                    IntPtr lineItemPointer;
                    lineItemPointer = DoGetTxnItemforList<T>(list, ref guid);
                    rec = Marshal.GetObjectForIUnknown(lineItemPointer) as Zout;
                }
                catch (Exception)
                {
                    yield break;
                }
                if (rec != null)
                {
                    yield return rec;
                }
                else
                {
                    yield break;
                }
                try
                {
                    DoNextforList<T>(list);
                }
                catch (Exception)
                {
                    yield break;
                }
            } while (true);
        }
        private enum IListType
        {
            X,
            Y,
            Unknown
        }
        private static IListType GetListTypeAsEnum<T>() where T : class
        {
            IListType rtType = IListType.Unknown;      
            Type inListType = typeof(T);
            if (inListType == typeof(IXList))
            {
                rtType = IListType.X;
            }
            else if (inListType == typeof(IYList))
            {
                rtType = IListType.Y;
            }
            return rtType;
        }
        private static IntPtr DoGetTxnItemforList<T>(T list, ref Guid guid) where T : class
        {
            IntPtr lineItemPointer;
            if (list == null)
            {
                throw new ArgumentNullException("end of list");
            }
            switch (GetListTypeAsEnum<T>())
            {
                case IListType.X:
                    ((IXList)list).GetItem(ref guid, out lineItemPointer);
                    break;
                case IListType.Y:
                    ((IYList)list).GetItem(ref guid, out lineItemPointer);
                    break;
                default:
                    throw new ArgumentException("unknown passed type");
            }
            return lineItemPointer;
        }
        private static void DoHeadforList<T>(T list) where T : class
        {
            if (list == null)
            {
                throw new ArgumentNullException("end of list");
            }
            switch (GetListTypeAsEnum<T>())
            {
                case IListType.X:
                    ((IXList)list).Head();
                    break;
                case IListType.Y:
                    ((IYList)list).Head();
                    break;
                default:
                    throw new ArgumentException("unknown passed type");
            }
        }
        private static void DoNextforList<T>(T list) where T : class
        {
            if (list == null)
            {
                throw new ArgumentNullException("end of list");
            }
            switch (GetListTypeAsEnum<T>())
            {
                case IListType.X:
                    ((IXList)list).Next();
                    break;
                case IListType.Y:
                    ((IYList)list).Next();
                    break;
                default:
                    throw new ArgumentException("unknown passed type");
            }
        }
