    public interface IPieceLogic
    {
        PieceType pieceType { get; }
        boolean isAlive { get; }
        List<Point> getAvailableMoves();
        boolean canMoveTo(Point position);
        void moveTo(Point newPosition);
        Point getPosition();
        void die();
    }
