			List<Card> results = new List<Card>(allMatches.FirstOrDefault ());
			for (int i = 1; i < allMatches.Count (); i++) {
				List<Card> other = allMatches [i];
				List<Card> toRemove = new List<Card> ();
				foreach(Card e in results) {
				
                //This comparison can be interpreted as other.Contains(e)
					if (other.Any(b => b.ID == e.ID)) {
						continue;
					}
					toRemove.Add (e);
				}
				foreach (Card e in toRemove) {
					results.Remove (e);
				}
			}
