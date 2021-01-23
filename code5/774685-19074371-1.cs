        internal static IEnumerable<IXOutList> GetAllLineItems(this IXList list)
        {
            TListEnumeratorBase genList = new IXListEnum(list);
            return GetAllLineItemsGeneric<IXOutList>(genList);
        }
        internal static IEnumerable<IYOutList> GetAllLineItems(this IYList list)
        {
            TListEnumeratorBase genList = new IYListEnum(list);
            return GetAllLineItemsGeneric<IYOutList>(genList);
        }                                                                                                                                   
        private static IEnumerable<Zout> GetAllLineItemsGeneric<Zout>(TListEnumeratorBase genList)
            where Zout : class     
        {
            try
            {
                genList.Head();
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
                    lineItemPointer = genList.GetTxnItem(ref guid);
                    rec = Marshal.GetObjectForIUnknown(lineItemPointer) as Zout;
                }
                catch (Exception)
                {
                    yield break;
                }
                if (rec != null)
                    yield return rec;
                else
                    yield break;
                try
                {
                    genList.Next();
                }
                catch (Exception)
                {
                    yield break;
                }
            } while (true);
        }
        public abstract class TListEnumeratorBase
        {
            public abstract void Head();
            public abstract void Next();
            public abstract IntPtr GetTxnItem(ref Guid guid);
        }
        public class IXListEnum : TListEnumeratorBase
        {
            IXList _list;
            public IXListEnum(IXList list)
            {
                _list = list;
            }
            public override void Head()
            {
                _list.Head();
            }
            public override void Next()
            {
                _list.Next();
            }
            public override IntPtr GetTxnItem(ref Guid guid)
            {
                IntPtr lineItemPointer;
                _list.Get(ref guid, out lineItemPointer);
                return lineItemPointer;
            }
        }
        public class IYListEnum : TListEnumeratorBase
        {
            IYList _list;
            public IYListEnum(IYList list)
            {
                _list = list;
            }
            public override void Head()
            {
                _list.Head();
            }
            public override void Next()
            {
                _list.Next();
            }
            public override IntPtr GetTxnItem(ref Guid guid)
            {
                IntPtr lineItemPointer;
                _list.Get(ref guid, out lineItemPointer);
                return lineItemPointer;
            }
        }
