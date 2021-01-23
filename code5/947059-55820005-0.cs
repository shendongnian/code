    private IEnumerable<TreeEntryChanges> GetDiffOfTrees(LibGit2Sharp.Repository repo, Tree oldTree,Tree newTree, CompareOptions compareOptions)
    {
            foreach (TreeEntryChanges change in repo.Diff.Compare<TreeChanges>(oldTree, newTree, compareOptions))
            {
                var changeStatus = change.Status;
                if (changeStatus == ChangeKind.Unmodified)
                {
                    continue;
                }
                yield return change;
            }
    }
