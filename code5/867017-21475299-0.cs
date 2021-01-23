    interface ITransactionVisitor {
        void Visit(PreAuthTransaction t);
        void Visit(VoidTransaction t);
        // etc.
    }
