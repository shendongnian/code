    private IEnumerable<TreeEntryChanges> GetDiffOfMergedTrees(Repository gitRepo, IEnumerable<LibGit2Sharp.Commit> parents, Tree tree, CompareOptions compareOptions)
    {
            var firstParent = parents.ElementAt(0);
            var secondParent = parents.ElementAt(1);
            var firstChanges = GetDiffOfTrees(gitRepo, firstParent.Tree, tree, compareOptions);
            var secondChanges = GetDiffOfTrees(gitRepo, secondParent.Tree, tree, compareOptions);
            var changes = firstChanges.Where(c1 => secondChanges.Any(c2 => c2.Oid == c1.Oid));
            return changes;
    }
