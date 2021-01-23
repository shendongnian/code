    // This is a run-of-the-mill visitor
    interface IVisitor {
        void VisitOwner(Owner owner);
        void VisitOwned(Owned owned);
    }
    // This is a base visitor class; it is abstract
    abstract class DefaultVisitor : IVisitor {
        public void VisitOwner(Owner owner) {
            BeginOwner(owner);
            BeginLiked();
            foreach (var owned in owner.Liked) {
                owned.Accept(this);
            }
            EndLiked();
            BeginDisliked();
            foreach (var owned in owner.Disliked) {
                owned.Accept(this);
            }
            EndDisliked();
            EndOwner(owner);
        }
        public void VisitOwned(Owned owned) {
            BeginOwned(owned);
            EndOwned(owned);
        }
        public abstract void BeginOwner(Owner owner);
        public abstract void EndOwner(Owner owner);
        public abstract void BeginOwned(Owned owned);
        public abstract void EndOwned(Owned owned);
        public abstract void BeginLiked();
        public abstract void EndLiked();
        public abstract void BeginDisliked();
        public abstract void EndDisliked();
    }
