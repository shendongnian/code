    public static void MoveAndRecalculateSequence(
        this IList<User> users, int moveFromIndex, int moveToIndex)
    {
        // Capture a reference to the user we want to move.
        var user = users[moveFromIndex];
        // Remove it from the list at it's current index.
        users.RemoveAt(moveFromIndex);
        // Insert the user at the required destination.
        users.Insert(moveToIndex, user);
        // Recalculate the seq number using the index of the list.
        for(int i = 0; i < users.length; i++)
        {
            users[i].SeqNumber = i + 1;
        }
    }
