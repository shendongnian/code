    [StructLayout(LayoutKind.Explicit)]
    public struct MMTPMsgDataUnion
    {
        [FieldOffset(0)]
        public MMTPConxReq ConxReq;
        [FieldOffset(0)]
        public MMTPConxAck ConxAck;
        [FieldOffset(0)]
        public MMTPConxNack ConxNack;
        [FieldOffset(0)]
        public MMTPErrInd ErrInd;
    }
