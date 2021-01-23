    // <summary>
    // Not Supported common processing
    // For all those cases where we don't intend to support
    // a nest operation as a child, we have this routine to
    // do the work.
    // </summary>
    private Node NestingNotSupported(Op op, Node n)
    {
        // First, visit my children
        VisitChildren(n);
        m_varRemapper.RemapNode(n);
    
        // Make sure we don't have a child that is a nest op.
        foreach (var chi in n.Children)
        {
            if (IsNestOpNode(chi))
            {
                throw new NotSupportedException(Strings.ADP_NestingNotSupported(op.OpType.ToString(), chi.Op.OpType.ToString()));
            }
        }
        return n;
    }
