    using System.Threading;
    public class LockFreeLinkPool<T> {
    
        private SingleLinkNode<T> head;
    
        public LockFreeLinkPool() {
            head = new SingleLinkNode<T>();
        }
    
        public void Push(SingleLinkNode<T> newNode) {
            newNode.Item = default(T);
            do {
                newNode.Next = head.Next;
            } while (!SyncMethods.CAS<SingleLinkNode<T>>(ref head.Next, newNode.Next, newNode));
            return;
        }
    
        public bool Pop(out SingleLinkNode<T> node) {
            do {
                node = head.Next;
                if (node == null) {
                    return false;
                }
            } while (!SyncMethods.CAS<SingleLinkNode<T>>(ref head.Next, node, node.Next));
            return true;
        }
    }
