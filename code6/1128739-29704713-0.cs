    public IEnumerator MoveNextTile() {
        // Ommited
        while (remainingMoves > 0) {
            //Ommited
            yield return StartCoroutine(MoveObject(fromVec, toVector, 1.0f));
            // Now MoveNextTile will continue after your MoveObject coroutine finishes.
        }
    }
