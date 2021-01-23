    private static class ChessMove {
        private String algebraicMove;
        private List<ChessMove> nextMoves = new ArrayList<>();
        // Maybe add a variation number too?
        public ChessMove(String algebraicMove) {
            this.algebraicMove = algebraicMove;
        }
        public void addMove(ChessMove chessMove) {
            nextMoves.add(chessMove);
        }
        public List<ChessMove> getNextMoves() {
            return nextMoves;
        }
    }
    public static void main(String[] args) throws Exception {
        ChessMove firstMove = new ChessMove("e4");
        firstMove.addMove(new ChessMove("e6")); // Add French defence
        firstMove.addMove(new ChessMove("c5")); // Add Sicilian defence
    }
