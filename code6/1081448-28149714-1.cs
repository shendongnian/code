    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program {
        class Blacklist {
            public string Start;
            public int Level;
            const int MaxLevel = 3;
            public Dictionary<string, Blacklist> SubBlacklists = new Dictionary<string, Blacklist>();
            public List<string> BlacklistedWords = new List<string>();
            public Blacklist() {
                Start = string.Empty;
                Level = 0;
            }
            Blacklist(string start, int level) {
                Start = start;
                Level = level;
            }
            public void AddBlacklistedWord(string word) {
                if (word.Length > Level && Level < MaxLevel) {
                    string index = word.Substring(0, Level + 1);
                    Blacklist sublist = null;
                    if (!SubBlacklists.TryGetValue(index, out sublist)) {
                        sublist = new Blacklist(index, Level + 1);
                        SubBlacklists[index] = sublist;
                    }
                    sublist.AddBlacklistedWord(word);
                } else {
                    BlacklistedWords.Add(word);
                }
            }
            public bool IsBlacklisted(string word) {
                if (word.Length > Level && Level < MaxLevel) {
                    string index = word.Substring(0, Level + 1);
                    foreach (var sublist in SubBlacklists.Values) {
                        if (word.Contains(sublist.Start)) {
                            return sublist.IsBlacklisted(word);
                        }
                    }
                    return false;
                } else {
                    return BlacklistedWords.Any(x => word.Contains(x));
                }
            }
        }
        static void Main(string[] args) {
            List<string> listUser = new List<string>();
            listUser.Add("user1");
            listUser.Add("user2");
            listUser.Add("userhacker");
            listUser.Add("userfukoff1");
            Blacklist blacklist = new Blacklist();
            blacklist.AddBlacklistedWord("hacker");
            blacklist.AddBlacklistedWord("fukoff");
            foreach (string user in listUser) {
                if (blacklist.IsBlacklisted(user)) {
                    Console.WriteLine("Contains blacklisted word: {0}", user);
                }
            }
        }
    }
